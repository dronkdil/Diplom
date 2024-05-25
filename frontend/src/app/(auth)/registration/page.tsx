'use client'
import { AuthenticationService } from "@/api/users/authentication/authentication.service"
import { RegistrationType } from "@/api/users/authentication/types/requests/registration.type"
import { SuccessAuthenticationType } from "@/api/users/authentication/types/responses/success-authentication.type"
import { AccentButton } from "@/components/buttons"
import DatePicker from "@/components/form/date-picker/DatePickerInput"
import { DefaultInput, PasswordInput } from "@/components/form/input"
import { useReduxActions } from "@/hooks/useReduxActions"
import { useTypedMutation } from "@/hooks/useTypedMutation"
import { Routes } from "@/lib/routes.constants"
import { Field } from "@headlessui/react"
import { Book, CalendarIcon, LockIcon, MailIcon, User2Icon } from "lucide-react"
import Link from "next/link"
import { useRouter } from "next/navigation"
import { useForm } from "react-hook-form"
import styles from "./../Auth.module.scss"

const RegistrationPage = () => {
	const {authenticate, saveUserData} = useReduxActions()
	const {register, getValues} = useForm()
	const router = useRouter()

	const {isPending, errors, mutateAsync: registration} = useTypedMutation<SuccessAuthenticationType>({
		name: 'login',
		request: () => AuthenticationService.registration(getValues() as RegistrationType),
		onSuccess: (o) => {
			authenticate(o.data.value)
			saveUserData(o.data.value.user)
			router.push(Routes.ProfileHome(o.data.value.user.role))
		}
	})

  return (
    <div className={styles.page}>
		<form className={styles.form}>
			<Field>
				<DefaultInput icon={<User2Icon />} placeholder="Ім'я" {...register("firstName")} error={errors.firstName} />
			</Field>
			<Field>
				<DefaultInput icon={<User2Icon />} placeholder="Фамілія" {...register("lastName")} error={errors.lastName} />
			</Field>
			<Field>
				<DefaultInput icon={<MailIcon />} placeholder="Почта" {...register("email")} error={errors.email} />
			</Field>
            <Field>
				<DatePicker icon={<CalendarIcon />} placeholder="Дата народження" {...register("birthday")} error={errors.birthday} />
			</Field>
            <Field>
				<DefaultInput icon={<Book />} placeholder="Освітній статус" {...register("educationalStatus")} error={errors.educationalStatus} />
			</Field>
            <Field>
				<PasswordInput icon={<LockIcon />} placeholder="Пароль" {...register("password")} error={errors.password} />
			</Field>
			<AccentButton isLoading={isPending} onClick={(e) => {
				e.preventDefault()
				registration()
			}}>Зареєструватись</AccentButton>
            <Link href={Routes.Login} className="text-white hover:underline">
                Вже э аккаунт? <span className="text-white/50">Вхід</span>
            </Link>
		</form>
    </div>
  )
}

export default RegistrationPage
