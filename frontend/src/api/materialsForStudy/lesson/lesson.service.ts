import $api from '@/api/api'
import { CreateLessonType } from './type/create-lesson.type'
import { UpdateLessonDescriptionType } from './type/update-description.type'
import { UpdateLessonHomeworkType } from './type/update-homework.type'
import { UpdateLessonTitleType } from './type/update-title.type'
import { UpdateLessonVideoByUrlType as UpdateLessonVideoWithYoutubeType } from './type/update-video-by-url.type'

export const LessonEndpoints = {
	create: '/lesson/create',
	remove: '/lesson/remove',
	updateTitle: '/lesson/update-title',
	updateDescription: '/lesson/update-description',
	updateVideoWithYoutube: '/lesson/update-video-with-youtube',
	updateHomework: '/lesson/update-homework',
	getForPage: (id: number) => `/lesson/get-for-page?id=${id}`
}

export const LessonService = {
	create: async (data: CreateLessonType) =>
		await $api.post(LessonEndpoints.create, data),
	remove: async (id: number) => await $api.post(LessonEndpoints.remove, { id }),
	getForPage: async (id: number) =>
		await $api.post(LessonEndpoints.getForPage(id)),
	updateTitle: async (data: UpdateLessonTitleType) =>
		await $api.post(LessonEndpoints.updateTitle, data),
	updateDescription: async (data: UpdateLessonDescriptionType) =>
		await $api.post(LessonEndpoints.updateDescription, data),
	updateHomework: async (data: UpdateLessonHomeworkType) =>
		await $api.post(LessonEndpoints.updateHomework, data),
	updateVideoWithYoutube: async (data: UpdateLessonVideoWithYoutubeType) =>
		await $api.post(LessonEndpoints.updateVideoWithYoutube, data)
}
