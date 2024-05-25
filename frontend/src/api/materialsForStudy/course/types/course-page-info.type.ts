export type CourseTypeInfoType = {
	id: number
	title: string
	description: string
	limitOfStudents: number
	teacher: TeacherType
	modules: ModuleType[]
}

type TeacherType = {
	id: number
	imageUrl: string
	firstName: string
	lastName: string
	email: string
}

type ModuleType = {
	id: number
	title: string
	description: string
	completedLessons: number
	lessons: []
}
