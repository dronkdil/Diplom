import { configureStore } from '@reduxjs/toolkit'
import { authenticationSlice } from './slices/AuthenticationSlice'
import { profileTitleSlice } from './slices/ProfileTitleSlice'
import { shortUserDataSlice } from './slices/UserSlice'
// ...

export const store = configureStore({
	reducer: {
		profileTitle: profileTitleSlice.reducer,
		authentication: authenticationSlice.reducer,
		userData: shortUserDataSlice.reducer
	}
})

// Get the type of our store variable
export type AppStore = typeof store
// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<AppStore['getState']>
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = AppStore['dispatch']
