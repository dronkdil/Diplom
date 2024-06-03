export type LessonForPageType = {
	id: number
	title: string
	description: string
	homeworkStatus: boolean
	homeworkDescription: string
	videoName: string
	videoType: string
	youtubeVideoId: string
	otherLessons: LessonForLinkType[]
}

type LessonForLinkType = {
	id: number
	title: string
}
