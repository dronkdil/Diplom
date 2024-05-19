"use client"
import { GhostButton, IconButton } from "@/components/buttons"
import { PenIcon, Undo2Icon } from "lucide-react"
import { useCallback, useState } from "react"
import styles from "./Setting.module.scss"

export type SettingProps = {
    title: string
    actualData: string
    children: any
    // sendRequest?: MutationFunction<AxiosResponse<any, any>>
}

const Setting = ({title, actualData, children}: SettingProps) => {
  // const [toastId, setToastId] = useState<any>(null)

	// const {
	// 	mutateAsync: changeSetting
	// } = useMutation<AxiosResponse, AxiosError<{ message: string }>>({
	// 	mutationKey: [`change-${title}`],
	// 	mutationFn: (v) => sentRequest!(v),
	// 	onMutate: () => {
	// 		toast.clearWaitingQueue()
	// 		setToastId(toast.loading('Змінюємо'))
	// 	},
	// 	onSuccess: () => {
	// 		onChangeSetting && onChangeSetting()
	// 		toast.update(toastId, { render: "Оновлено", type: "success", isLoading: false, closeOnClick: true, autoClose: 2000 });
	// 	},
	// 	onSettled: () => {
	// 		toast.clearWaitingQueue()
	// 		setChanging(false)
	// 	},
	// 	onError: (err) => {
	// 		toast.update(toastId, { render: err.response?.data.message, type: "error", isLoading: false, closeOnClick: true, autoClose: 2000 });
	// 	}
	// })
	
	const [changing, setChanging] = useState(false)

	const toggleChangingMode = useCallback(() => {
		setChanging(o => !o)
	}, [])

	return <div className={styles.setting}>
			<div>
        <h6 className={styles.setting__title}>{title}</h6>
        {changing 
          ? <div className={styles.setting__inputs}>
            {children}
          </div>
          : <span className={styles["setting__actual-data"]}>{actualData}</span>
        }
      </div>
      <div className={styles.setting__buttons}>
        <IconButton
          onClick={(e) => {
            toggleChangingMode()
          }}
        >
          {changing 
            ? <Undo2Icon className={styles.setting__icon} /> 
            : <PenIcon className={styles.setting__icon} />}
        </IconButton>

        {changing && <GhostButton>
          Зберегти
        </GhostButton>}
      </div>
	</div>
}

export default Setting
