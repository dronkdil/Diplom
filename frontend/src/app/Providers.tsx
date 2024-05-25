"use client"
import { persistor, store } from "@/lib/redux/store"
import { QueryClient, QueryClientProvider } from "@tanstack/react-query"
import { Provider } from "react-redux"
import { PersistGate } from "redux-persist/integration/react"

const queryClient = new QueryClient()

const Providers = ({children}: {children: React.ReactNode}) => {
  return (
    <QueryClientProvider client={queryClient}>
      <Provider store={store}>
        <PersistGate loading={false} persistor={persistor}>
          {children}
        </PersistGate>
      </Provider>
    </QueryClientProvider>
  )
}

export default Providers
