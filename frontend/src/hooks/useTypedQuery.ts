import { ApiResponse } from '@/api/response.type'
import { useQuery } from '@tanstack/react-query'
import { AxiosError, AxiosResponse } from 'axios'
import { useEffect, useState } from 'react'

export type QueryResponse<TData> = AxiosResponse<ApiResponse<TData>>
type QueryError = AxiosError<ApiResponse>

export type UseQueryOptions<TData> = {
	name: string
	request: () => Promise<QueryResponse<TData>>
	// onSuccess?: (response: QueryResponse<TData>) => void
	conditional?: () => boolean
	successConditional?: (response: QueryResponse<TData> | undefined) => boolean
}

export const useTypedQuery = <TData>({
	name,
	request,
	conditional,
	successConditional
}: UseQueryOptions<TData>) => {
	successConditional ??= () => true

	const [data, setData] = useState<TData>()
	const [successConditionalResult, setSuccessConditionalResult] =
		useState<boolean>(true)
	const {
		data: axiosResponse,
		isPending,
		refetch,
		isSuccess,
		isError
	} = useQuery<QueryResponse<TData>, QueryError>({
		queryKey: [name],
		queryFn: request,
		enabled: conditional && conditional()
	})

	useEffect(() => {
		setData(axiosResponse?.data.value)
		if (successConditional)
			setSuccessConditionalResult(successConditional(axiosResponse))
	}, [axiosResponse])

	return {
		axiosResponse,
		data,
		isPending,
		refetch,
		setData: setData,
		isSuccessResponse: isPending
			? undefined
			: isSuccess &&
			  successConditionalResult &&
			  axiosResponse?.data.type == 'Successfully',
		isFailedResponse: isPending
			? undefined
			: isError ||
			  !successConditionalResult ||
			  axiosResponse?.data.type != 'Successfully'
	}
}
