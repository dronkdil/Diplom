import $api from '@/api/api'
import { CreateModuleType } from './type/create-module.type'
import { UpdateModuleDescriptionType } from './type/update-description.type'
import { UpdateModuleTitleType } from './type/update-title.type'

export const ModuleEndpoints = {
	create: '/module/create',
	remove: '/module/remove',
	updateTitle: '/module/update-title',
	updateDescription: '/module/update-description',
	getModuleForSettings: (id: number) => `/module/get-for-settings?id=${id}`
}

export const ModuleService = {
	create: async (data: CreateModuleType) =>
		await $api.post(ModuleEndpoints.create, data),
	remove: async (id: number) => await $api.post(ModuleEndpoints.remove, { id }),
	updateTitle: async (data: UpdateModuleTitleType) =>
		await $api.post(ModuleEndpoints.updateTitle, data),
	updateDescription: async (data: UpdateModuleDescriptionType) =>
		await $api.post(ModuleEndpoints.updateDescription, data),
	getModuleForSettings: async (id: number) =>
		await $api.get(ModuleEndpoints.getModuleForSettings(id))
}
