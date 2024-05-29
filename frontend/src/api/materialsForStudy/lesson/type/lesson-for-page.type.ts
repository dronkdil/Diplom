export type LessonForPageType = {
	id: number
	title: string
	description: string
	homeworkStatus: boolean
	homeworkDescription: string
	videoUrl: string
	otherLessons: LessonForLinkType[]
}

type LessonForLinkType = {
	id: number
	title: string
}
