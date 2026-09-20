import React from 'react'
import BasicText from '../components/BasicLayoutComponents/BasicText'
import BasicView from '../components/BasicLayoutComponents/BasicView'
import { ScrollView } from 'react-native-gesture-handler'

const AboutScreen = () => {
    return (
        <ScrollView>
            <BasicView className="px-6 py-10 gap-6">
                <BasicView className="gap-2 flex-none bg-transparent">
                    <BasicText variant="secondary">
                        Turn your daily steps into progress for your cat companion.
                    </BasicText>
                </BasicView>
                <BasicView className="gap-4 flex-none bg-transparent">
                    <BasicView className="gap-2 flex-none rounded-2xl bg-neutral-100 dark:bg-neutral-800 p-5">
                        <BasicText variant="label">
                            Add Your Cat
                        </BasicText>

                        <BasicText>
                            Create your own cat companion and make it part of your daily routine.
                            Your cat grows with you as you stay active and keep moving.
                        </BasicText>
                    </BasicView>
                    <BasicView className="gap-2 flex-none rounded-2xl bg-neutral-100 dark:bg-neutral-800 p-5">
                        <BasicText variant="label">
                            Level Up With Steps
                        </BasicText>
                        <BasicText>
                            Every step you take helps your cat gain progress. Walking, exploring,
                            and reaching your step goals will help your cat level up and become stronger.
                        </BasicText>
                    </BasicView>
                    <BasicView className="gap-2 flex-none rounded-2xl bg-neutral-100 dark:bg-neutral-800 p-5">
                        <BasicText variant="label">
                            Improve Your Stats
                        </BasicText>
                        <BasicText>
                            As your cat levels up, its stats will increase. The more consistent
                            you are, the more your companion can grow into a powerful and unique cat.
                        </BasicText>
                    </BasicView>
                    <BasicView className="gap-2 flex-none rounded-2xl bg-neutral-100 dark:bg-neutral-800 p-5">
                        <BasicText variant="label">
                            Coming Soon
                        </BasicText>
                        <BasicText>
                            Future updates will introduce battling and bonus items. These features
                            will give your cat new ways to compete, improve, and unlock exciting rewards.
                        </BasicText>
                    </BasicView>
                </BasicView>
            </BasicView>
        </ScrollView>
    )
}

export default AboutScreen