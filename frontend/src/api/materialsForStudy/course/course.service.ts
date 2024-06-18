import $api from '@/api/api'
import { UpdateCourseChatLinkType } from './types/update-chat-link.type'
import { UpdateCourseDescriptionType } from './types/update-description.type'
import { UpdateCourseImageByUrlType } from './types/update-image-by-url.type'
import { UpdateCourseScheduleLinkType } from './types/update-schedule-link.type'
import { UpdateCourseTitleType } from './types/update-title.type'

export const CourseEndpoints = {
	create: '/course/create',
	remove: '/course/remove',
	getAll: '/course/all',
	updateTitle: '/course/update-title',
	updateDescription: '/course/update-description',
	updateImageByUrl: '/course/update-image-by-url',
	updateChatLink: '/course/update-chat-link',
	updateScheduleLink: '/course/update-schedule-link',
	getCourse: (id: number) => `/course/get-page-data?courseId=${id}`,
	getAverageScore: (id: number) => `/course/get-average-score?courseId=${id}`
}

export const CourseService = {
	getCourse: async (id: number) =>
		await $api.get(CourseEndpoints.getCourse(id)),
	getAllCourses: async () => await $api.get(CourseEndpoints.getAll),
	updateTitle: async (data: UpdateCourseTitleType) =>
		await $api.post(CourseEndpoints.updateTitle, data),
	updateDescription: async (data: UpdateCourseDescriptionType) =>
		await $api.post(CourseEndpoints.updateDescription, data),
	updateImageByUrl: async (data: UpdateCourseImageByUrlType) =>
		await $api.post(CourseEndpoints.updateImageByUrl, data),
	updateChatLink: async (data: UpdateCourseChatLinkType) =>
		await $api.post(CourseEndpoints.updateChatLink, data),
	updateScheduleLink: async (data: UpdateCourseScheduleLinkType) =>
		await $api.post(CourseEndpoints.updateScheduleLink, data),
	getAverageScore: async (id: number) =>
		await $api.get(CourseEndpoints.getAverageScore(id))
}
