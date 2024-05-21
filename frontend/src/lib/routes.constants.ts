export const Routes = {
	Home: '/',
	Profile: {
		MyData: '/profile/my-data',
		StudentCourses: '/profile/student-courses',
		TeacherCourses: '/profile/teacher-courses',
		TeacherCourse: (id: number) => `/profile/teacher-courses/${id}`,
		Certificates: '/profile/my-certificates',
		CertificateById: (id: number) => `/profile/certifications/${id}`,
		Notification: '/profile/notifications',
		Settings: '/profile/settings'
	},
	Login: '/login',
	Registration: '/registration',
	Courses: '/courses',
	Course: (id: number) => `/courses/${id}`,
	Lesson: (id: number) => `/courses/lesson/${id}`,
	Teacher: {
		Courses: '/profile/teacher-courses',
		Course: (id: number) => `/profile/teacher-courses/${id}`,
		LessonSettings: (id: number) => `/profile/teacher-courses/lesson/${id}`,
		LessonHomeworks: (id: number) =>
			`/profile/teacher-courses/lesson/${id}/homeworks`
	}
}
