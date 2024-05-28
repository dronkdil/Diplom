import $api from '@/api/api'
import { CreateLessonType } from './type/create-lesson.type'
import { UpdateDescriptionType } from './type/update-description.type'
import { UpdateHomeworkType } from './type/update-homework.type'
import { UpdateTitleType } from './type/update-title.type'
import { UpdateVideoByUrlType } from './type/update-video-by-url.type'

export const LessonEndpoints = {
	create: '/lesson/create',
	remove: '/lesson/remove',
	updateTitle: '/lesson/update-title',
	updateDescription: '/lesson/update-description',
	updateVideoByUrl: '/lesson/update-video-by-url',
	updateHomework: '/lesson/update-homework',
	getForPage: (id: number) => `/lesson/get-for-page?id=${id}`
}

export const LessonService = {
	create: async (data: CreateLessonType) =>
		await $api.post(LessonEndpoints.create, data),
	remove: async (id: number) => await $api.post(LessonEndpoints.remove, { id }),
	getForPage: async (id: number) =>
		await $api.post(LessonEndpoints.getForPage(id)),
	updateTitle: async (data: UpdateTitleType) =>
		await $api.post(LessonEndpoints.updateTitle, data),
	updateDescription: async (data: UpdateDescriptionType) =>
		await $api.post(LessonEndpoints.updateDescription, data),
	updateHomework: async (data: UpdateHomeworkType) =>
		await $api.post(LessonEndpoints.updateHomework, data),
	updateVideoByUrl: async (data: UpdateVideoByUrlType) =>
		await $api.post(LessonEndpoints.updateVideoByUrl, data)
}
