export type SuccessAuthenticationType = {
	accessToken: string
	refreshToken: string
	user: {
		id: number
		firstName: string
		lastName: string
		email: string
		role: string
	}
}
