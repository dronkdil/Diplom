import { ApiResponse, ResponseError } from '@/api/response.type'
import { useMutation } from '@tanstack/react-query'
import { AxiosError, AxiosResponse } from 'axios'
import { useState } from 'react'

export type MutationResponse<TData> = AxiosResponse<ApiResponse<TData>>
type MutationError = AxiosError<ApiResponse>

export type UseMutationOptions<TData> = {
	name: string
	request: () => Promise<MutationResponse<TData>>
	onSuccess?: (response: MutationResponse<TData>) => void
	onError?: (errors: Record<string, ResponseError>) => void
	conditional?: () => boolean
}

export const useTypedMutation = <TData>({
	name,
	request,
	onSuccess,
	onError,
	conditional
}: UseMutationOptions<TData>) => {
	const [errors, setErrors] = useState<Record<string, ResponseError>>({})
	const { mutateAsync, isPending } = useMutation<
		MutationResponse<TData>,
		MutationError
	>({
		mutationKey: [name],
		mutationFn: () => {
			if (conditional == null || conditional()) return request()
			else return Promise.reject()
		},
		onError: (o) => {
			if (conditional && conditional() == false) return

			const errors = o.response?.data.errors
			const recordedErrors = errors?.reduce(
				(acc, o) => ({ ...acc, [o.propertyName]: o }),
				{} as Record<string, ResponseError>
			)
			setErrors(recordedErrors ?? {})

			onError && onError(recordedErrors ?? {})
		},
		onSuccess: (response) => {
			onSuccess && onSuccess(response)
			setErrors({})
		}
	})

	return { mutateAsync, isPending, errors, setErrors }
}
