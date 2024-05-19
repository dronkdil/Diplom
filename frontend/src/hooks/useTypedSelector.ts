import { RootState } from '@/lib/redux/store'
import { useSelector } from 'react-redux'

type StateFunction = (state: RootState) => any

export function useTypedSelector(stateFunction: StateFunction) {
	return useSelector(stateFunction)
}
