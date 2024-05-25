import $api from '@/api/api'

export const TeacherEndpoints = {
	create: '/teacher/create',
	remove: '/teacher/remove',
	getCourses: '/teacher/courses',
	getAll: '/teacher/all'
}

export const TeacherService = {
	getCourses: async () => await $api.get(TeacherEndpoints.getCourses)
}
