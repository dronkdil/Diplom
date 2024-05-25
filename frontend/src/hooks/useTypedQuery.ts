import { ApiResponse } from '@/api/response.type'
import { useQuery } from '@tanstack/react-query'
import { AxiosError, AxiosResponse } from 'axios'

export type QueryResponse<TData> = AxiosResponse<ApiResponse<TData>>
type QueryError = AxiosError<ApiResponse>

export type UseQueryOptions<TData> = {
	name: string
	request: () => Promise<QueryResponse<TData>>
	onSuccess?: (response: QueryResponse<TData>) => void
	conditional?: () => boolean
}

export const useTypedQuery = <TData>({
	name,
	request,
	onSuccess,
	conditional
}: UseQueryOptions<TData>) => {
	const { data, isPending, refetch } = useQuery<
		QueryResponse<TData>,
		QueryError
	>({
		queryKey: [name],
		queryFn: request,
		enabled: conditional && conditional()
	})

	return { data, isPending, refetch }
}
