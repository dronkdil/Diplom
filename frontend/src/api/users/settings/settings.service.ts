import $api from '@/api/api'
import { UpdateNamesType } from './type/update-names.type'
import { UpdatePasswordType } from './type/update-password.type'

export const SettingsEndpoints = {
	updateNames: '/settings/update-first-last-names',
	updatePassword: '/settings/update-password',
	updateBirthday: '/settings/update-birthday',
	updateEducationalStatus: '/settings/update-educational-status'
}

export const SettingsService = {
	updateNames: async (data: UpdateNamesType) =>
		await $api.post(SettingsEndpoints.updateNames, data),
	updatePassword: async (data: UpdatePasswordType) =>
		await $api.post(SettingsEndpoints.updatePassword, data)
}
