"use client"
import { Listbox, ListboxButton, ListboxOption, ListboxOptions, Transition } from "@headlessui/react"
import { useState } from "react"
import InputWrapper from "../input/wrapper/InputWrapper"
import styles from "./ListboxInput.module.scss"

export type ListboxInputProps = {
    values: any[]
    icon: React.ReactElement
    placeholder?: string
}

const ListboxInput = ({values, icon, placeholder}: ListboxInputProps) => {
    const [value, setValue] = useState(null)

    return (
        <Listbox  
            value={value} 
            onChange={setValue}
            className={styles.listbox}
            as={"div"}
        >
            <ListboxButton className="w-full">
                <InputWrapper icon={icon} onFocus={() => {}} wrapperClassName="w-full">
                    {value ? <span className="text-white">{value}</span> : <span className="text-white/50">{placeholder}</span>}
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
                            {o}
                        </ListboxOption>
                    ))}
                </ListboxOptions>
            </Transition>
        </Listbox>
    )

}

export default ListboxInput
