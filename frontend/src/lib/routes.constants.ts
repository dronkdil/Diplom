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
		TeacherCourse: (id: any) => `/profile/teacher-courses/${id}`,
		Certificates: '/profile/my-certificates',
		CertificateById: (id: any) => `/profile/certifications/${id}`,
		Notification: '/profile/notifications',
		Settings: '/profile/settings'
	},
	Login: '/login',
	Registration: '/registration',
	Courses: '/courses',
	Course: (id: any) => `/courses/${id}`,
	Lesson: (id: any) => `/courses/lesson/${id}`,
	CommonUser: {
		MyData: '/profile/my-data',
		Notification: '/profile/notifications',
		Settings: '/profile/settings'
	},
	Student: {
		Courses: '/profile/student-courses',
		Certificates: '/profile/my-certificates',
		CertificateById: (id: any) => `/profile/certifications/${id}`
	},
	Teacher: {
		Courses: '/profile/teacher-courses',
		Course: (id: any) => `/profile/teacher-courses/${id}`,
		LessonSettings: (id: any) => `/profile/teacher-courses/lesson/${id}`,
		LessonHomeworks: (id: any) =>
			`/profile/teacher-courses/lesson/${id}/homeworks`,
		ModuleSettings: (id: any) => `/profile/teacher-courses/module/${id}`,
		CourseStudents: (id: any) => `/profile/teacher-courses/${id}/students`
	}
}
