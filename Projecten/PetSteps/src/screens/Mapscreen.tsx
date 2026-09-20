import React, { useEffect, useRef, useState } from 'react'
import { ActivityIndicator, StyleSheet, View } from 'react-native'
import MapView, { Camera, LatLng, Polyline } from 'react-native-maps'
import {
    getCurrentPositionAsync,
    watchPositionAsync,
    Accuracy,
    LocationSubscription,
    useBackgroundPermissions,
    useForegroundPermissions,
} from 'expo-location'
import BasicText from '../components/BasicLayoutComponents/BasicText'
import BasicView from '../components/BasicLayoutComponents/BasicView'

const Mapscreen = () => {
    const mapRef = useRef<MapView>(null)
    const locationSubscription = useRef<LocationSubscription | null>(null)

    const [foregroundStatus, requestForegroundPermission] =
        useForegroundPermissions()

    const [backgroundStatus, requestBackgroundPermission] =
        useBackgroundPermissions()

    const [initialCamera, setInitialCamera] = useState<Camera | null>(null)
    const [routeCoordinates, setRouteCoordinates] = useState<LatLng[]>([])

    useEffect(() => {
        if (!foregroundStatus || (!foregroundStatus.granted && foregroundStatus.canAskAgain)) {
            requestForegroundPermission()
        }
    }, [foregroundStatus])

    useEffect(() => {
        if (
            foregroundStatus?.granted &&
            backgroundStatus &&
            !backgroundStatus.granted &&
            backgroundStatus.canAskAgain
        ) {
            requestBackgroundPermission()
        }
    }, [foregroundStatus?.granted, backgroundStatus])

    useEffect(() => {
        const startTracking = async () => {
            if (!foregroundStatus?.granted) return

            const currentLocation = await getCurrentPositionAsync({
                accuracy: Accuracy.High,
            })

            const currentCoordinate = {
                latitude: currentLocation.coords.latitude,
                longitude: currentLocation.coords.longitude,
            }

            const camera = {
                center: currentCoordinate,
                heading: 0,
                pitch: 0,
                zoom: 17,
            }

            setInitialCamera(camera)
            setRouteCoordinates([currentCoordinate])

            locationSubscription.current = await watchPositionAsync(
                {
                    accuracy: Accuracy.High,
                    timeInterval: 1000,
                    distanceInterval: 2,
                },
                (location) => {
                    const coordinate = {
                        latitude: location.coords.latitude,
                        longitude: location.coords.longitude,
                    }

                    setRouteCoordinates((previousCoordinates) => [
                        ...previousCoordinates,
                        coordinate,
                    ])

                    mapRef.current?.animateCamera(
                        {
                            center: coordinate,
                            zoom: 17,
                        },
                        { duration: 500 }
                    )
                }
            )
        }

        startTracking()

        return () => {
            locationSubscription.current?.remove()
        }
    }, [foregroundStatus?.granted])

    if (!foregroundStatus?.granted || !initialCamera) {
        return (
            <BasicView className="items-center justify-center">
                <ActivityIndicator size="large" />

                <BasicText variant="caption" className="mt-3">
                    Getting your location...
                </BasicText>
            </BasicView>
        )
    }

    return (
        <View className="flex-1">
            <MapView
                ref={mapRef}
                style={styles.map}
                showsUserLocation
                showsMyLocationButton
                initialCamera={initialCamera}
                onMapReady={() => {
                    mapRef.current?.animateCamera(initialCamera, { duration: 500 })
                }}
            >
                <Polyline
                    coordinates={routeCoordinates}
                    strokeColor="#0EA5E9"
                    strokeWidth={5}
                    lineCap="round"
                    lineJoin="round"
                />
            </MapView>
        </View>
    )
}

export default Mapscreen

const styles = StyleSheet.create({
    map: {
        flex: 1,
    },
})