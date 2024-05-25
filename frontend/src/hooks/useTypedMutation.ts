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
}

export const useTypedMutation = <TData>({
	name,
	request,
	onSuccess
}: UseMutationOptions<TData>) => {
	const [errors, setErrors] = useState<Record<string, ResponseError>>({})
	const { mutateAsync, isPending } = useMutation<
		MutationResponse<TData>,
		MutationError
	>({
		mutationKey: [name],
		mutationFn: request,
		onError: (o) => {
			const errors = o.response?.data.errors
			const recordedErrors = errors?.reduce(
				(acc, o) => ({ ...acc, [o.propertyName]: o }),
				{} as Record<string, ResponseError>
			)
			setErrors(recordedErrors ?? {})
		},
		onSuccess: (response) => {
			onSuccess && onSuccess(response)
		}
	})

	return { mutateAsync, isPending, errors }
}
