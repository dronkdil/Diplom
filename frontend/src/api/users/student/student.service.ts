import $api from '@/api/api'

export const StudentEndpoints = {
	getAll: '/student/all',
	joinCourse: '/student/join-course',
	getMyData: '/student/get-my-data'
}

export const StudentService = {
	getMyData: async () => await $api.get(StudentEndpoints.getMyData)
}
