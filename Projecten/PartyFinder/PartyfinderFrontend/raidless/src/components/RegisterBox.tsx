import { useForm } from 'react-hook-form'
import { yupResolver } from '@hookform/resolvers/yup'
import * as yup from 'yup'
import axios from 'axios'
import type { PlayerRequestContract, MemberRequestPayload } from "../types/types"
import { BaseURILocal } from '../uris'
import { useAuth } from 'react-oidc-context';
import { useState } from 'react'
import Loading from './Loading'


const schema = yup.object({
    email: yup.string().email('Invalid email format').required('Email is required'),
    userName: yup.string().max(16, 'Username must be 16 characters or less').required('Username is required'),
    password: yup.string().required('Password is required').min(6).matches(
        /[A-Z]/,
        'Password must contain at least one capital letter'
    )
        .matches(
            /[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]/,
            'Password must contain at least one symbol'
        )
}).required();

const RegisterBox = () => {
    const { register, handleSubmit, formState: { errors } } = useForm<PlayerRequestContract>({
        resolver: yupResolver(schema)
    });

    const { user, signinRedirect } = useAuth();
    const [loading, setLoading] = useState(false);


    const onSubmit = async (data: PlayerRequestContract) => {
        setLoading(true);
        try {
            const response = await axios.post('https://localhost:5001/api/users/register', data);
            console.log(response.data.id, typeof (response.data.id));

            const MemberPayload: MemberRequestPayload = {
                Username: data.userName,
                IdentityServerId: response.data.id
            }

            const responseMember = await axios.post(BaseURILocal + "/Members", MemberPayload)

            if (response.status === 200 && responseMember.status === 201) {
                signinRedirect();
            }
        } catch (error) {
            console.error('Error:', error);
        }
    };
    if (loading) {
        <Loading />
    }
    return (
        <div className=" p-8 rounded-lg shadow-lg  mx-auto border border-black">
            <h2 className="text-2xl font-bold text-blue-200 mb-6 text-center">Register</h2>
            <form onSubmit={handleSubmit(onSubmit)} className="space-y-4 flex-col justify-center items-center">
                <div>
                    <input
                        type="email"
                        placeholder="Email"
                        {...register('email')}
                        className="w-full px-4 py-2 rounded bg-blue-950 text-white border border-blue-700 focus:outline-none focus:border-blue-500"
                    />
                    {errors.email && <p className="text-red-400 text-sm mt-1">{errors.email.message}</p>}
                </div>

                <div>
                    <p>Register with your OSRS Username</p>
                    <input
                        type="text"
                        placeholder="Username (max 16 characters)"
                        {...register('userName')}
                        maxLength={16}
                        className="w-full px-4 py-2 rounded bg-blue-950 text-white border border-blue-700 focus:outline-none focus:border-blue-500"
                    />
                    {errors.userName && <p className="text-red-400 text-sm mt-1">{errors.userName.message}</p>}
                </div>

                <div>
                    <input
                        type="password"
                        placeholder="Password"
                        {...register('password')}
                        className="w-full px-4 py-2 rounded bg-blue-950 text-white border border-blue-700 focus:outline-none focus:border-blue-500"
                    />
                    {errors.password && <p className="text-red-400 text-sm mt-1">{errors.password.message}</p>}
                </div>

                <button
                    type="submit"
                    className="w-full bg-blue-600 hover:bg-blue-700 text-white font-medium py-2 px-4 rounded transition-colors cursor-pointer"
                >
                    Register
                </button>
            </form>
        </div>
    );
};

export default RegisterBox;