import type { RootState } from '@/lib/redux/store'
import { PayloadAction, createSlice } from '@reduxjs/toolkit'

type PayloadType = {
	value: boolean
}

const initialState: PayloadType = {
	value: false
}

export const isJoinedCourseSlice = createSlice({
	name: 'is-joined-course',
	initialState,
	reducers: {
		setIsJoinedCourse: (state, { payload }: PayloadAction<boolean>) => {
			state.value = payload
		}
	}
})

export const getIsJoinedCourse = (state: RootState) => state.joinedCourse.value
