import { type RootState } from '@/lib/redux/store'
import { PayloadAction, createSlice } from '@reduxjs/toolkit'

type PayloadType = {
	accessToken: string
	refreshToken: string
	authenticated: boolean
}

const initialState: PayloadType = {
	accessToken: '',
	refreshToken: '',
	authenticated: false
}

export const authenticationSlice = createSlice({
	name: 'authentication',
	initialState: {
		value: initialState
	},
	reducers: {
		authenticate: (
			state,
			{ payload }: PayloadAction<Omit<PayloadType, 'authenticated'>>
		) => {
			state.value = {
				...payload,
				authenticated: true
			}
		},
		logoutOnClient: (state) => {
			state.value = {
				...initialState,
				authenticated: false
			}
		}
	}
})

export const getAuthenticated = (state: RootState) =>
	state.authentication.value.authenticated

export const getAccessToken = (state: RootState) =>
	state.authentication.value.accessToken
