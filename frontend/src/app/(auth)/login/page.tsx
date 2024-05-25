'use client'
import { ResponseError } from "@/api/response.type"
import { AuthenticationService } from "@/api/users/authentication/authentication.service"
import { LoginType } from "@/api/users/authentication/types/requests/login.type"
import { SuccessAuthenticationType } from "@/api/users/authentication/types/responses/success-authentication.type"
import { AccentButton } from "@/components/buttons"
import { SwitchCheckbox } from "@/components/form"
import { DefaultInput, PasswordInput } from "@/components/form/input"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedMutation } from "@/hooks/useTypedMutation"
import { Routes } from "@/lib/routes.constants"
import { Field, Label } from "@headlessui/react"
import { LockIcon, Repeat2Icon, User2Icon } from "lucide-react"
import Link from "next/link"
import { useRouter } from "next/navigation"
import { useForm } from "react-hook-form"
import styles from "./../Auth.module.scss"

const LoginPage = () => {
	const {authenticate, saveUserData} = useReduxActions()
	const {register, getValues} = useForm()
	const router = useRouter()

	const {isPending, errors, setErrors, mutateAsync: login} = useTypedMutation<SuccessAuthenticationType>({
		name: 'login',
		request: () => AuthenticationService.login(getValues() as LoginType),
		onSuccess: (o) => {
			authenticate(o.data.value)
			saveUserData(o.data.value.user)
			router.push(Routes.ProfileHome(o.data.value.user.role))
		},
		conditional: () => {
			if (getValues().password != getValues().confirmPassword) {
				setErrors({ConfirmPassword: {errorMessage: "Поролі не співпадають"} as ResponseError})
				return false
			}

			return true
		}
	})

	return (
		<div className="flex-auto grid place-content-center">
			<form className="flex flex-col gap-3">
				<Field>
					<DefaultInput {...register("email")} icon={<User2Icon />} placeholder="Пошта" error={errors.email} />
				</Field>
				<Field>
					<PasswordInput {...register("password")} icon={<LockIcon />} placeholder="Пароль" error={errors.password} />
				</Field>
				<Field>
					<PasswordInput {...register("confirmPassword")} icon={<Repeat2Icon />} placeholder="Повторіть пароль" error={errors.confirmPassword} />
				</Field>
				<Field className={styles["switch-field"]}>
					<Label>Запам’ятати мене</Label>
					<SwitchCheckbox />
				</Field>
				<AccentButton isLoading={isPending} onClick={(e) => {
					e.preventDefault(); 
					login()
				}}>
					Увійти
				</AccentButton>
				<Link href={Routes.Registration} className="text-white hover:underline">
					Немає облікового запису? <br /> <span className="text-white/50">Зареєструватись</span>
				</Link>
			</form>
		</div>
	)
}

export default LoginPage
