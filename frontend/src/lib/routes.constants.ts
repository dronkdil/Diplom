export const Routes = {
	Home: '/',
	ProfileHome: (role: string) => {
		const routes = {
			Student: Routes.Student.Courses,
			Teacher: Routes.Teacher.Courses
		} as Record<string, string>
		return routes[role] ?? '/'
	},
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
	CommonUser: {
		MyData: '/profile/my-data',
		Notification: '/profile/notifications',
		Settings: '/profile/settings'
	},
	Student: {
		Courses: '/profile/student-courses',
		Certificates: '/profile/my-certificates',
		CertificateById: (id: number) => `/profile/certifications/${id}`
	},
	Teacher: {
		Courses: '/profile/teacher-courses',
		Course: (id: number) => `/profile/teacher-courses/${id}`,
		LessonSettings: (id: number) => `/profile/teacher-courses/lesson/${id}`,
		LessonHomeworks: (id: number) =>
			`/profile/teacher-courses/lesson/${id}/homeworks`,
		ModuleSettings: (id: number) => `/profile/teacher-courses/module/${id}`
	}
}
