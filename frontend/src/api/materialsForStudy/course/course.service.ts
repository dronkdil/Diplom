import $api from '@/api/api'

export const CourseEndpoints = {
	create: '/course/create',
	remove: '/course/remove',
	getAll: '/course/all',
	updateTitle: '/course/update-title',
	updateDescription: '/course/update-description',
	getCourse: (id: number) => `/course/get-page-data?courseId=${id}`
}

export const CourseService = {
	getCourse: async (id: number) => await $api.get(CourseEndpoints.getCourse(id))
}
