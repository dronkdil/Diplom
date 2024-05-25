import $api from '@/api/api'
import { ApiResponse } from '@/api/response.type'
import { LoginType } from './types/requests/login.type'
import { RegistrationType } from './types/requests/registration.type'
import { SuccessAuthenticationType } from './types/responses/success-authentication.type'

export const AuthenticationEndpoints = {
	login: '/login',
	registration: '/student/registration',
	refresh: '/refresh',
	logout: '/logout'
}

export const AuthenticationService = {
	login: async (data: LoginType) =>
		await $api.post<ApiResponse<SuccessAuthenticationType>>(
			AuthenticationEndpoints.login,
			data
		),
	registration: async (data: RegistrationType) =>
		await $api.post<ApiResponse<SuccessAuthenticationType>>(
			AuthenticationEndpoints.registration,
			data
		),
	refresh: async () =>
		await $api.post<ApiResponse<SuccessAuthenticationType>>(
			AuthenticationEndpoints.refresh
		),
	logout: async () =>
		await $api.post<ApiResponse>(AuthenticationEndpoints.logout)
}
