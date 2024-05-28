import type { RootState } from '@/lib/redux/store'
import { PayloadAction, createSlice } from '@reduxjs/toolkit'

export type UserDataType = {
	id: number
	firstName: string
	lastName?: string
	email: string
	role: string
	displayName: string
}

const initialStateValue = {
	id: 0,
	firstName: '',
	lastName: undefined,
	role: '',
	email: ''
} as UserDataType

export const shortUserDataSlice = createSlice({
	name: 'short-user-data',
	initialState: {
		value: initialStateValue
	},
	reducers: {
		saveUserData: (state, { payload }: PayloadAction<UserDataType>) => {
			state.value = payload
		},
		clearUserData: (state) => {
			state.value = initialStateValue
		}
	}
})

export const getUserData = (state: RootState): UserDataType =>
	state.userData.value!
