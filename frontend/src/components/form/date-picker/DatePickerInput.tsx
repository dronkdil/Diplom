import { InputMask } from '@react-input/mask'
import { HtmlHTMLAttributes, createRef, forwardRef } from 'react'
import { mergeRefs } from 'react-merge-refs'
import { DefaultInputProps } from '../input/default/DefaultInput'
import InputWrapper from '../input/wrapper/InputWrapper'
import defaultStyles from "./../input/default/DefaultInput.module.scss"

export type DatePickerProps = HtmlHTMLAttributes<HTMLDivElement> & DefaultInputProps

const DatePicker = forwardRef(({icon, wrapperClassName, ...props}: DatePickerProps, ref) => {
    const innerRef = createRef<HTMLInputElement>()
    return (
        <InputWrapper icon={icon} onFocus={() => innerRef.current?.focus()}>
            <InputMask ref={mergeRefs([innerRef, ref])} className={defaultStyles.default__input} {...props} mask="дд.мм.рррр" replacement={{ "д": /\d/, "м": /\d/, "р": /\d/ }} separate showMask={false}  />
        </InputWrapper>
    )
})

export default DatePicker