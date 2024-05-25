import type { RootState } from '@/lib/redux/store'
import { PayloadAction, createSlice } from '@reduxjs/toolkit'

export type UserDataType = {
	id: number
	firstName: string
	lastName: string
	email: string
	role: string
	displayName: string
}

const initialState: UserDataType = {
	id: 0,
	firstName: '',
	lastName: '',
	email: '',
	role: '',
	displayName: ''
}

export const shortUserDataSlice = createSlice({
	name: 'short-user-data',
	initialState: {
		value: initialState
	},
	reducers: {
		saveUserData: (state, { payload }: PayloadAction<UserDataType>) => {
			state.value = payload
		},
		clearUserData: (state) => {
			state.value = initialState
		}
	}
})

export const getUserData = (state: RootState): UserDataType =>
	state.userData.value
