import $api from '@/api/api'

export const StudentEndpoints = {
	getAll: '/student/all',
	joinCourse: '/student/join-course',
	leaveCourse: '/student/leave-course',
	getMyData: '/student/get-my-data',
	getCourses: '/student/courses',
	alreadyJoinedCourse: (courseId: number) =>
		`/student/already-joined-course?courseId=${courseId}`,
	getByCourse: (courseId: number) =>
		`/student/get-by-course?courseId=${courseId}`
}

export const StudentService = {
	getMyData: async () => await $api.get(StudentEndpoints.getMyData),
	getCourses: async () => await $api.get(StudentEndpoints.getCourses),
	alreadyJoinedCourse: async (courseId: number) =>
		await $api.get(StudentEndpoints.alreadyJoinedCourse(courseId)),
	joinCourse: async (courseId: number) =>
		await $api.post(StudentEndpoints.joinCourse, { courseId }),
	leaveCourse: async (courseId: number) =>
		await $api.post(StudentEndpoints.leaveCourse, { courseId }),
	getByCourse: async (courseId: number) =>
		await $api.get(StudentEndpoints.getByCourse(courseId))
}
