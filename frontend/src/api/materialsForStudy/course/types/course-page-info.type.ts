export type CourseTypeInfoType = {
	id: number
	imageUrl: string
	title: string
	description: string
	limitOfStudents: number
	teacher: TeacherType
	modules: ModuleType[]
}

export type TeacherType = {
	id: number
	imageUrl: string
	firstName: string
	lastName: string
	email: string
}

export type ModuleType = {
	id: number
	title: string
	description: string
	completedLessons: number
	lessons: LessonType[]
}

export type LessonType = {
	id: number
	title: string
}
