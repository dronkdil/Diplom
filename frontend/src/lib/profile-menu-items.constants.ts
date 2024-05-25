import { Routes } from './routes.constants'

export const ProfileMenuItems = [
	{
		href: Routes.Student.Courses,
		text: 'Мої курси',
		role: 'Student'
	},
	{
		href: Routes.Teacher.Courses,
		text: 'Мої курси',
		role: 'Teacher'
	},
	{
		href: Routes.Student.Certificates,
		text: 'Мої сертифікати',
		role: 'Student'
	},
	{
		href: Routes.CommonUser.Notification,
		text: 'Повідомлення',
		role: undefined
	},
	{
		href: Routes.CommonUser.MyData,
		text: 'Власні дані',
		role: undefined
	},
	{
		href: Routes.CommonUser.Settings,
		text: 'Налаштування',
		role: 'Student'
	}
]
