import $api from '@/api/api'
import { UpdateCourseDescriptionType } from './types/update-description.type'
import { UpdateCourseImageByUrlType } from './types/update-image-by-url.type'
import { UpdateCourseTitleType } from './types/update-title.type'

export const CourseEndpoints = {
	create: '/course/create',
	remove: '/course/remove',
	getAll: '/course/all',
	updateTitle: '/course/update-title',
	updateDescription: '/course/update-description',
	updateImageByUrl: '/course/update-image-by-url',
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
	getAverageScore: async (id: number) =>
		await $api.get(CourseEndpoints.getAverageScore(id))
}
