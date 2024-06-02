import $api from '@/api/api'
import { CancelHomeworkType } from './types/cancel-homework.type'
import { EvaluateHomeworkType } from './types/evaluate-homework.type'
import { SendHomeworkType } from './types/send-homework.type'

export const HomeworkEndpoints = {
	send: '/homework/send',
	cancel: '/homework/cancel',
	evaluate: '/homework/evaluate',
	getByStudent: (id: number, lessonId: number) =>
		`/homework/get-by-student?id=${id}&lessonId=${lessonId}`,
	getByLesson: (id: number) => `/homework/get-by-lesson?id=${id}`
}

export const HomeworkService = {
	send: async (data: SendHomeworkType) =>
		await $api.post(HomeworkEndpoints.send, data),
	cancel: async (data: CancelHomeworkType) =>
		await $api.post(HomeworkEndpoints.cancel, data),
	evaluate: async (data: EvaluateHomeworkType) =>
		await $api.post(HomeworkEndpoints.evaluate, data),
	getByStudent: async (id: number, lessonId: number) =>
		await $api.get(HomeworkEndpoints.getByStudent(id, lessonId)),
	getByLesson: async (id: number) =>
		await $api.get(HomeworkEndpoints.getByLesson(id))
}
