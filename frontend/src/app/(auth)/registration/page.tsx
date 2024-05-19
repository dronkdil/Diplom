'use client'
import { ListboxInput } from "@/components/form"
import DatePicker from "@/components/form/date-picker/DatePickerInput"
import { DefaultInput, PasswordInput } from "@/components/form/input"
import AccentLink from "@/components/links/accent/AccentLink"
import { Routes } from "@/lib/routes.constants"
import { Field } from "@headlessui/react"
import { Book, CalendarIcon, LockIcon, MailIcon, MessageCircleIcon, User2Icon } from "lucide-react"
import Link from "next/link"
import { useState } from "react"
import styles from "./../Auth.module.scss"

const RegistrationPage = () => {
    const [type, setType] = useState(false)

  return (
    <div className={styles.page}>
		<form action="" className={styles.form}>
			<Field>
				<DefaultInput icon={<User2Icon />} placeholder="Логін" />
			</Field>
			<Field>
				<DefaultInput icon={<MailIcon />} placeholder="Почта" />
			</Field>
            <Field>
				<DatePicker icon={<CalendarIcon />} placeholder="Дата народження" />
			</Field>
            <Field>
				<DefaultInput icon={<MessageCircleIcon />} placeholder="Вік" />
			</Field>
            <Field>
				<ListboxInput icon={<Book />} values={["test", "ddd", "text"]} placeholder="Освітній статус" />
			</Field>
            <Field>
				<PasswordInput icon={<LockIcon />} placeholder="Пароль" />
			</Field>
			<AccentLink href={Routes.Profile.Courses}>Зареєструватись</AccentLink>
            <Link href={Routes.Login} className="text-white hover:underline">
                Вже э аккаунт? <span className="text-white/50">Вхід</span>
            </Link>
		</form>
    </div>
  )
}

export default RegistrationPage
