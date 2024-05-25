import type { RootState } from '@/lib/redux/store'
import { PayloadAction, createSlice } from '@reduxjs/toolkit'

type PayloadType = {
	value: string
}

const initialState: PayloadType = {
	value: ''
}

export const profileTitleSlice = createSlice({
	name: 'profile-title',
	initialState,
	reducers: {
		setProfileTitle: (state, { payload }: PayloadAction<string>) => {
			state.value = payload
		}
	}
})

export const getProfileTitle = (state: RootState) => state.profileTitle.value
