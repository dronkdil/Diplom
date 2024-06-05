import { authenticationSlice } from '@/lib/redux/slices/AuthenticationSlice'
import { isJoinedCourseSlice } from '@/lib/redux/slices/IsJoinedCourseSlice'
import { profileTitleSlice } from '@/lib/redux/slices/ProfileTitleSlice'
import { shortUserDataSlice } from '@/lib/redux/slices/UserSlice'
import { bindActionCreators } from '@reduxjs/toolkit'
import { useMemo } from 'react'
import { useDispatch } from 'react-redux'

export function useReduxActions() {
	const dispatch = useDispatch()

	return useMemo(
		() =>
			bindActionCreators(
				{
					...profileTitleSlice.actions,
					...authenticationSlice.actions,
					...shortUserDataSlice.actions,
					...isJoinedCourseSlice.actions
				},
				dispatch
			),
		[dispatch]
	)
}
