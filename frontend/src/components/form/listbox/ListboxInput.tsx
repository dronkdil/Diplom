"use client"
import { Listbox, ListboxButton, ListboxOption, ListboxOptions, Transition } from "@headlessui/react"
import { forwardRef, useState } from "react"
import InputWrapper from "../input/wrapper/InputWrapper"
import styles from "./ListboxInput.module.scss"

export type ListboxInputProps = {
    values: ListboxInputItem[]
    icon: React.ReactElement
    placeholder?: string
    onChange?: (item: ListboxInputItem) => void
}

export type ListboxInputItem = {
    id: number
    text: any
}

const ListboxInput = forwardRef<HTMLElement, ListboxInputProps>(({values, icon, placeholder, onChange}: ListboxInputProps, ref) => {
    const [value, setValue] = useState<ListboxInputItem | null>(null)

    return (
        <Listbox
            value={value?.id} 
            onChange={o => {
                const listItem = o as unknown as ListboxInputItem
                setValue(listItem)
                onChange && onChange(listItem)
            }}
            className={styles.listbox}
            as={"div"}
            ref={ref}
        >
            <ListboxButton className="w-full">
                <InputWrapper icon={icon} onFocus={() => {}} wrapperClassName="w-full">
                    {value ? <span className="text-white">{value.text}</span> : <span className="text-white/50">{placeholder}</span>}
                </InputWrapper>
            </ListboxButton>
            <Transition
                enter="duration-100 ease-out"
                enterFrom="scale-95 opacity-0"
                enterTo="scale-100 opacity-100"
                leave="duration-100 ease-out"
                leaveFrom="scale-100 opacity-100"
                leaveTo="scale-80 opacity-0"
            >
                <ListboxOptions className={styles.listbox__options}>
                    {values.map((o, i) => (
                        <ListboxOption key={i} value={o} className={styles.listbox__item}>
                            {o.text}
                        </ListboxOption>
                    ))}
                </ListboxOptions>
            </Transition>
        </Listbox>
    )

})

export default ListboxInput
