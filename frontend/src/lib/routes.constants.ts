export const Routes = {
	Home: '/',
	Profile: {
		MyData: '/profile/my-data',
		Courses: '/profile/my-courses',
		Certificates: '/profile/my-certificates',
		CertificateById: (id: number) => `/profile/certifications/${id}`,
		Notification: '/profile/notifications',
		Settings: '/profile/settings'
	},
	Login: '/login',
	Registration: '/registration',
	Courses: '/courses'
}
