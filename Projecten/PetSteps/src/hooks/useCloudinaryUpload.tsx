import * as ImagePicker from 'expo-image-picker'
import { useMutation } from '@tanstack/react-query'
import { Cloudinary } from '@cloudinary/url-gen'
import { upload } from 'cloudinary-react-native'

const CLOUD_NAME = process.env.EXPO_PUBLIC_CLOUDINARY_CLOUD_NAME ?? ''
const UPLOAD_PRESET = process.env.EXPO_PUBLIC_CLOUDINARY_UPLOAD_PRESET ?? ''

const cld = new Cloudinary({
    cloud: { cloudName: CLOUD_NAME },
})

const uploadToCloudinary = async (uri: string): Promise<string> => {
    return new Promise((resolve, reject) => {
        upload(cld, {
            file: uri,
            options: {
                upload_preset: UPLOAD_PRESET,
                unsigned: true,
            },
            callback: (error: any, response: any) => {
                if (error) {
                    console.log('Upload error:', error)
                    reject(new Error('Upload failed'))
                } else {
                    resolve(response.secure_url as string)
                }
            },
        })
    })
}

export const useCloudinaryUpload = () => {
    const { mutateAsync, isPending, error } = useMutation({
        mutationFn: uploadToCloudinary,
    })

    const pickImage = async (): Promise<string | null> => {
        const permission = await ImagePicker.requestMediaLibraryPermissionsAsync()

        if (!permission.granted) {
            return null
        }

        const result = await ImagePicker.launchImageLibraryAsync({
            mediaTypes: ['images'],
            allowsEditing: false,
            quality: 0.8,
        })

        if (result.canceled) {
            return null
        }

        return result.assets[0].uri
    }

    const uploadImage = async (uri: string): Promise<string | null> => {
        try {
            const url = await mutateAsync(uri)
            return url
        } catch (error) {
            console.log('Upload image error:', error)
            return null
        }
    }

    const pickAndUpload = async (): Promise<string | null> => {
        const uri = await pickImage()

        if (!uri) return null

        return uploadImage(uri)
    }

    return {
        pickImage,
        uploadImage,
        pickAndUpload,
        isUploading: isPending,
        error: error?.message ?? null,
    }
}
