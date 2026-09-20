import { ActivityIndicator, TouchableOpacity, View, Text } from 'react-native'
import React, { useEffect, useRef, useState } from 'react'
import { useCameraPermissions, CameraType, CameraView } from 'expo-camera'
import { useIsFocused } from '@react-navigation/native'
import { useMediaLibraryPermissions } from 'expo-image-picker'
import { saveToLibraryAsync } from 'expo-media-library'
import * as Haptics from 'expo-haptics'

const CameraScreen = () => {

    const [status, requestPermission] = useCameraPermissions();
    const [mediaStatus, requestMediaPermission] = useMediaLibraryPermissions();
    const [isCameraReady, setIsCameraReady] = useState(false);

    const isFocused = useIsFocused();

    const cameraRef = useRef<CameraView>(null);

    useEffect(() => {
        if (status?.canAskAgain) {
            requestPermission();
        }
    }, [status?.canAskAgain]);

    return (
        <View className='flex-1'>
            {isFocused && (<CameraView onCameraReady={() => (setIsCameraReady(true))} ref={cameraRef} facing='back' style={{ flex: 1 }} />)}
            <TouchableOpacity
                className="absolute bottom-10 self-center h-20 w-20 items-center justify-center rounded-full border-4 border-white bg-white/30"
                onPress={async () => {
                    if (isCameraReady) {
                        try {
                            await Haptics.impactAsync(
                                Haptics.ImpactFeedbackStyle.Medium
                            );
                            const picture = await cameraRef.current?.takePictureAsync();
                            if (picture) {
                                if (!mediaStatus?.granted) {
                                    await requestMediaPermission();
                                }
                                await saveToLibraryAsync(picture.uri);
                                console.log("Foto is opgeslagen in de galerij");
                            }

                            console.log(picture);
                        } catch (error) {
                            console.log(error);
                        }
                    }
                }}>
            </TouchableOpacity>
        </View>

    )
}

export default CameraScreen;