'use client'
import { SwitchCheckbox } from "@/components/form"
import { DefaultInput, PasswordInput } from "@/components/form/input"
import AccentLink from "@/components/links/accent/AccentLink"
import { Routes } from "@/lib/routes.constants"
import { Field, Label } from "@headlessui/react"
import { LockIcon, Repeat2Icon, User2Icon } from "lucide-react"
import Link from "next/link"
import styles from "./../Auth.module.scss"

const LoginPage = () => {
  return (
    <div className="flex-auto grid place-content-center">
		<form action="" className="flex flex-col gap-3">
			<Field>
				<DefaultInput icon={<User2Icon />} placeholder="Логін" />
			</Field>
			<Field>
				<PasswordInput icon={<LockIcon />} placeholder="Пароль" />
			</Field>
			<Field>
				<PasswordInput icon={<Repeat2Icon />} placeholder="Повторіть пароль" />
			</Field>
			<Field className={styles["switch-field"]}>
				<Label>Запам’ятати мене</Label>
				<SwitchCheckbox />
			</Field>
			<AccentLink href={Routes.Profile.StudentCourses}>Увійти</AccentLink>
			<Link href={Routes.Registration} className="text-white hover:underline">
                Немає облікового запису? <br /> <span className="text-white/50">Зареєструватись</span>
            </Link>
		</form>
    </div>
  )
}

export default LoginPage
