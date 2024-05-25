export type ApiResponse<T = null> = {
	type: string
	errors: ResponseError[]
	value: T
}

export type ResponseError = {
	propertyName: string
	errorMessage: string
	actualValue: number | string | Date
}
