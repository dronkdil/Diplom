import { profileTitleSlice } from '@/lib/redux/slices/ProfileTitleSlice'
import { bindActionCreators } from '@reduxjs/toolkit'
import { useMemo } from 'react'
import { useDispatch } from 'react-redux'

export function useReduxActions() {
	const dispatch = useDispatch()

	return useMemo(
		() =>
			bindActionCreators(
				{
					...profileTitleSlice.actions
				},
				dispatch
			),
		[dispatch]
	)
}
