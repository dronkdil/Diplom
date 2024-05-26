import { authenticationSlice } from '@/lib/redux/slices/AuthenticationSlice'
import { shortUserDataSlice } from '@/lib/redux/slices/UserSlice'
import { store } from '@/lib/redux/store'
import axios from 'axios'
import {
	AuthenticationEndpoints,
	AuthenticationService
} from './users/authentication/authentication.service'

const $api = axios.create({
	withCredentials: true,
	baseURL: 'http://localhost:5152/' // process.env.NEXT_PUBLIC_SERVER_URL
})

$api.interceptors.request.use((config) => {
	const accessToken = store.getState().authentication.value.accessToken
	config.headers.Authorization = `Bearer ${accessToken}`
	return config
})

$api.interceptors.response.use(
	(response) => response,
	async (error) => {
		const originalRequest = error.config
		const status = error.response?.status
		const url = originalRequest.url

		console.log(url, error)

		if (
			url !== AuthenticationEndpoints.refresh &&
			(status === 401 || status === 403)
		) {
			const { data, status } = await AuthenticationService.refresh()
			if (status >= 400) return Promise.reject(error)

			store.dispatch(authenticationSlice.actions.authenticate(data.value))
			store.dispatch(shortUserDataSlice.actions.saveUserData(data.value.user))
			return $api(originalRequest)
		}

		return Promise.reject(error)
	}
)

export default $api
