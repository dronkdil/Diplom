"use client"
import { GhostButton, IconButton } from "@/components/buttons"
import { useTypedMutation } from "@/hooks/useTypedMutation"
import { PenIcon, Undo2Icon } from "lucide-react"
import { useCallback, useState } from "react"
import { FieldValues, useForm } from "react-hook-form"
import styles from "./Setting.module.scss"

export type SettingProps = {
    title: string
    actualData: string
    children: (register: (fieldName: string) => any) => any
    request?: (values: FieldValues) => Promise<any>
}

const Setting = ({title, actualData, children, request}: SettingProps) => {
	const {mutateAsync, isPending, errors} = useTypedMutation({
		name: `setting-[${title}]`,
		request: () => request!(getValues()),
		conditional: () => !!request,
		onSuccess: () => {
			setChanging(false)
		}
	})
	
	const [changing, setChanging] = useState(false)

	const toggleChangingMode = useCallback(() => {
		setChanging(o => !o)
	}, [])

	const {register, getValues} = useForm()

	const newRegister = useCallback((fieldName: string) => {
		return {...register(fieldName), error: errors[fieldName]}
	}, [])

	return <div className={styles.setting}>
		<div>
			<h6 className={styles.setting__title}>{title}</h6>
			{changing 
				? <div className={styles.setting__inputs}>
					{children(newRegister)}
				</div>
				: <span className={styles["setting__actual-data"]}>{actualData}</span>
			}
		</div>
		<div className={styles.setting__buttons}>
			{changing && <GhostButton isLoading={isPending} onClick={() => mutateAsync()}>
				Зберегти
			</GhostButton>}
			<IconButton
				onClick={(e) => toggleChangingMode()}
			>
			{changing 
				? <Undo2Icon className={styles.setting__icon} /> 
				: <PenIcon className={styles.setting__icon} />}
			</IconButton>
		</div>
	</div>
}

export default Setting