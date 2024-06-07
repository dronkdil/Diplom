import $api from '@/api/api'

export const NotificationEndpoints = {
	getForUser: (userId: number) => `/notification/get-for-user?userId=${userId}`
}

export const NotificationService = {
	getForUser: async (userId: number) =>
		await $api.get(NotificationEndpoints.getForUser(userId))
}
