import { ModuleService } from '@/api/materialsForStudy/modules/module.service'
import { IconButton } from '@/components/buttons'
import IconLink from '@/components/links/icon/IconLink'
import { useTypedMutation } from '@/hooks/useTypedMutation'
import { Routes } from '@/lib/routes.constants'
import { Disclosure, DisclosureButton, DisclosurePanel } from '@headlessui/react'
import { ChevronDownIcon, SettingsIcon, TrashIcon } from 'lucide-react'
import styles from "./Module.module.scss"

export type ModuleProps = {
    title: string
    description: string
    children: any
    id: number
    onDeleted: (id: number) => void
}

const Module = ({title, children, id, description, onDeleted}: ModuleProps) => {

  const {mutateAsync: deleteModule, isPending} = useTypedMutation({
    name: `remove-module-${id}`,
    request: () => ModuleService.remove(id),
    onSuccess: () => {
      onDeleted(id)
    }
  })

  return (
    <Disclosure as={"div"} className={styles.module}>
      {({open}) => <>
        <div className={styles.module__header}>
          <DisclosureButton as='div' className={styles.module__button}>
            <span className={styles.module__title}>{title}</span>
            <IconButton className={`${styles["module__down-icon"]} ${open && styles["module__down-icon--active"]}`}><ChevronDownIcon /></IconButton>
          </DisclosureButton>
          <IconLink href={Routes.Teacher.ModuleSettings(id)}><SettingsIcon /></IconLink>
          <IconButton isLoading={isPending} onClick={() => deleteModule()}><TrashIcon /></IconButton>
        </div>
        <DisclosurePanel className={styles.module__items}>
            <p className={styles.module__description}>{description}</p>
            {children}
        </DisclosurePanel>
      </>}
    </Disclosure>
  )
}

export default Module
