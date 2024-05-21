'use client'
import { useEffect } from 'react'
import { useReduxActions } from './useReduxActions'

export function useProfilePageTitle(title: string) {
	const { setProfileTitle } = useReduxActions()
	useEffect(() => {
		setProfileTitle('Мої курси')
	}, [])
}
