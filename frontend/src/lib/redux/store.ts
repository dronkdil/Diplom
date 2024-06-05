import { configureStore } from '@reduxjs/toolkit'
import { combineReducers } from 'redux'
import {
	FLUSH,
	PAUSE,
	PERSIST,
	PURGE,
	REGISTER,
	REHYDRATE,
	persistReducer,
	persistStore
} from 'redux-persist'
import storage from 'redux-persist/es/storage'
import { authenticationSlice } from './slices/AuthenticationSlice'
import { isJoinedCourseSlice } from './slices/IsJoinedCourseSlice'
import { profileTitleSlice } from './slices/ProfileTitleSlice'
import { shortUserDataSlice } from './slices/UserSlice'

const persistConfig = {
	key: 'root',
	storage
}

const rootReducer = combineReducers({
	profileTitle: profileTitleSlice.reducer,
	authentication: persistReducer(
		{ key: 'auth', storage },
		authenticationSlice.reducer
	),
	userData: persistReducer(
		{ key: 'user-data', storage },
		shortUserDataSlice.reducer
	),
	joinedCourse: isJoinedCourseSlice.reducer
})

const persistedReducer = persistReducer(persistConfig, rootReducer)

export const store = configureStore({
	reducer: persistedReducer,
	middleware: (getDefaultMiddleware) =>
		getDefaultMiddleware({
			serializableCheck: {
				ignoredActions: [FLUSH, REHYDRATE, PAUSE, PERSIST, PURGE, REGISTER]
			}
		})
})

export const persistor = persistStore(store)

export type AppStore = typeof store
export type RootState = ReturnType<AppStore['getState']>
export type AppDispatch = AppStore['dispatch']
