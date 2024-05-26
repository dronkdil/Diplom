import $api from '@/api/api'
import { CreateModuleType } from './type/create-module.type'

export const ModuleEndpoints = {
	create: '/module/create',
	remove: '/module/remove',
	updateTitle: '/module/update-title',
	updateDescription: '/module/update-description'
}

export const ModuleService = {
	create: async (data: CreateModuleType) =>
		await $api.post(ModuleEndpoints.create, data),
	remove: async (id: number) => await $api.post(ModuleEndpoints.remove, { id })
}
