import { ActualUserType } from '@/api/users/settings/type/user.type'
import type { RootState } from '@/lib/redux/store'
import { PayloadAction, createSlice } from '@reduxjs/toolkit'

export type UserDataType = {
	id: number
	firstName: string
	lastName?: string
	email: string
	role: string
	displayName: string
	avatarUrl?: string
}

const initialStateValue = {
	id: 0,
	firstName: '',
	lastName: undefined,
	role: '',
	email: '',
	avatarUrl: undefined
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
		},
		updateUserData: (state, { payload }: PayloadAction<ActualUserType>) => {
			state.value = {
				...state.value,
				...payload
			}
		}
	}
})

export const getUserData = (state: RootState): UserDataType =>
	state.userData.value!
